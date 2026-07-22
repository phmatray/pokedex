// Service worker : réseau d'abord, cache en secours. À l'installation, précharge les données
// et les icônes (l'app de 2016 était installée avec tout son contenu local — même contrat) ;
// les illustrations se mettent en cache à la visite.
const CACHE = 'pkdx-v1';

self.addEventListener('install', event => {
  event.waitUntil(
    caches.open(CACHE).then(cache =>
      fetch('data/precache.json')
        .then(reponse => reponse.json())
        .then(entrees => Promise.allSettled(entrees.map(u => cache.add(u))))
        .catch(() => {})
    )
  );
});

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
