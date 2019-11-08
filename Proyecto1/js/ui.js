const recetas = document.querySelector('.recipes');

document.addEventListener("DOMContentLoaded", function() {
    // nav menu
    const menus = document.querySelectorAll(".side-menu");
    M.Sidenav.init(menus, { edge: "right" });
    // add recipe form
    const forms = document.querySelectorAll(".side-form");
    M.Sidenav.init(forms, { edge: "left" });
  });

  //Renderizacion de las recetas
  const renderRecetas = (data,id) =>  {
    const html= `
    <div class="card-panel recipe white row" data-id="${id}">
      <img alt="recipe thumb" src="/img/dish.png"/>
      <div class="recipe-details">
        <div class="recipe-title">${data.nombre}</div>
        <div class="recipe-description">${data.descripcion}</div>
        <div class="recipe-ingredients">${data.ingredientes}</div>
        <div class="recipe-title"><img src=${data.imagen}></div>
      </div>
      <div class="recipe-delete">
        <i class="material-icons" data-id="${id}">delete_outline</i>
      </div>
    </div>
    `;

    recetas.innerHTML += html;
  };