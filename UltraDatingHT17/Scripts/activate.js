// DENNA FUNKTION SER TILL SÅ ATT CSS-KLASSERNA "AKTIVERAS" O FÅR RÄTT UTSEENDE
 //LADDAS MED FÖRDEL VID PAGE LOAD

function changeActive(menuItem, titleBarText) {

    var activeMenuItem = document.getElementById(menuItem);
  $(activeMenuItem).addClass('active');
  document.getElementById('titlebar-text').innerHTML = titleBarText;
}