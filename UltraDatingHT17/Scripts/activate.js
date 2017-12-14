// CALL THIS FUNTION ON PAGE LOAD WITH THE ID OF
// WHATEVER ITEM YOU WISH TO "ACTIVATE" AND
// TGHE TEXT YOU WISH TO EMBED IN PAGE TITLE

function changeActive(menuItem, titleBarText) {

  var activeMenuItem = document.getElementById(menuItem)
  $(activeMenuItem).addClass('active');
  document.getElementById('titlebar-text').innerHTML = titleBarText;
}