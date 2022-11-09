const btnMobile = document.getElementById('btn-mobile');
let header = document.getElementById('header')
function toggleMenu() {
    console.log("Funcionou!!!")
    let nav = document.getElementById('nav');
    
    nav.classList.toggle('active');
    header.classList.toggle('heigth');
}


btnMobile.addEventListener('click', toggleMenu);