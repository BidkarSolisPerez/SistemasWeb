const cacheEstatico = "site-static";
const cacheDinamico = "site-dynamic";
const assets = [
    "/",
    "/index.html",
    "/js/app.js",
    "/js/ui.js",
    "/js/materialize.min.js",
    "/css/materialize.min.css",
    "/css/styles.css",
    "/img/dish.png",
    "https://fonts.googleapis.com/icon?family=Material+Icons"
];

self.addEventListener('install', evt => {
    evt.waitUntil(
        caches.open(cacheEstatico).then(cache => {
            //console.log("Agregando al cache del sitio web");
            cache.addAll(assets);
        })
    )
    //console.log('el service worker ha sido instalado');
    });

self.addEventListener('activate', evt => {
        //console.log('ha sido activado');
        evt.waitUntil(
            caches.keys().then(keys => {
                return Promise.all(keys
                    .filter(key => key != cacheEstatico)
                    .map(key => caches.delete(key))
                    )
            })
        );
});

//fetch event
self.addEventListener("fetch", evt => {
    
    if(evt.request.url.indexOf('firestore.googleapis.com') === -1){
        evt.respondWith(
            caches.match(evt.request).then(cacheRes => {
                return cacheRes || fetch(evt.request).then(async fetchRes => {
                    const cache = await caches.open(cacheDinamico);
                    cache.put(evt.request.url, fetchRes.clone());
                    return fetchRes;
                });
            })
        );
    }
    /*
    evt.respondWith(
        caches.match(evt.request).then(cacheRes => {
        return cacheRes || fetch(evt.request);
        })
        );*/
    //console.log("fetch event", evt);
});