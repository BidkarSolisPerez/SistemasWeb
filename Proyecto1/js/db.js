// datos mantenidos fuera de linea
DataBaseCon.enablePersistence()
.catch(err => {
    if(err.code == 'failed-precondition'){
        //probablemente muchas ventanas abiertas a la vez
        console.log("La persistencia de datos fallo");
    }else if(err == 'unimplemented'){
        //falta de soporte del browser
        console.log("Persistencia no esta disponible");
    }
})

// en tiempo real traer datos con cambios nuevos al agregar o eliminar
DataBaseCon.collection('recetas').onSnapshot((snaphot) => {
    //console.log(snaphot.docChanges());
    snaphot.docChanges().forEach(change => {
        //console.log(change, change.doc.data(), change.doc.id);
        if(change.type === "added"){
            // add document data to web page
            renderRecetas(change.doc.data(), change.doc.id);
        }else if(change.type === "removed"){
            //remove the document data from webpage
        }
    });
});


//Agregar una nueva receta
const form = document.querySelector('form');

form.addEventListener('submit',evt => {
    evt.preventDefault();

    var urlImage;

    var file = document.getElementById('image');

    console.log(file.files.item(0).name);

    var receta;

    // Create a root reference
var storageRef = firebase.storage().ref();

storageRef.child('imagesRecetas/' + file.files.item(0).name).put(file.files.item(0)).then(() =>{
    var starsRef = storageRef.child('imagesRecetas/'+file.files.item(0).name);

// Get the download URL
urlImage = "Me cago en todo";

console.log(urlImage);
starsRef.getDownloadURL().then(function(url){
  this.url = url;
  urlImage = this.url;
  console.log("teste: " + this.url);
  console.log("URL: "+urlImage);
    receta = {
        nombre: form.title.value,
        descripcion: form.description.value,
        ingredientes: form.ingredients.value,
        imagen: urlImage
    };

    console.log(receta);


    DataBaseCon.collection('recetas').add(receta)
    .catch(err => console.log(err));
    


   form.title.value ='';
   form.description.value ='';
   form.ingredients.value ='';
   form.image.value = '';
});



  })
})