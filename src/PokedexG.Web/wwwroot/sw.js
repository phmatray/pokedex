// Service worker minimal : réseau d'abord, cache en secours (utilisable hors-ligne après une visite).
const CACHE = 'pkdx-v1';

self.addEventListener('fetch', event => {
  if (event.request.method !== 'GET') return;
  event.respondWith(
    fetch(event.request)
      .then(response => {
        const copy = response.clone();
        caches.open(CACHE).then(cache => cache.put(event.request, copy)).catch(() => {});
        return response;
      })
      .catch(() => caches.match(event.request).then(hit => hit
        // La racine est en cache sous l'URL du répertoire (./), jamais sous index.html.
        ?? caches.match('./').then(root => root ?? caches.match('index.html'))))
  );
});

self.addEventListener('activate', event => {
  event.waitUntil(
    caches.keys().then(keys => Promise.all(keys.filter(k => k !== CACHE).map(k => caches.delete(k))))
  );
});
