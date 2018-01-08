$("#menu-button").click(function () {

    // våran dropdownmeny aktiveras och görs synlig genom att klicka på vår knapp med id menu-button

    var menu = document.getElementById("dropdown");
    var menuButton = document.getElementById("menu-button");
    if (menu.style.display === "none") {
        menu.style.display = "block";
        menuButton.innerHTML = "&#x274c;";
    } else {
        menu.style.display = "none";
        menuButton.innerHTML = "&#9776";
    }

    // skapar en lista att fylla med de items som finns i vår meny

    var menuItems = [];

    $("#main-menu a").each(function () {
        var el = $(this);
        menuItems.push(el);
        //alert(el.text());
    });

    // tar bort det sista itemet ur samlingen, då det bara är knappen som visar menyn
    menuItems.splice(-1, 1);


    // skapar en ny lista för de items vi vill "flytta" till vår dropdown
    var dropdown = [];

    for (i = 0; i < menuItems.length; i++) {
        var item =
            '<a href="' +
            menuItems[i].attr("href") +
            '">' +
            menuItems[i].text() +
            "</a><br>";
        dropdown.push(item);
    }

    dropdown = dropdown.join("");

    document.getElementById("dropdown").innerHTML = dropdown;
});


// dölj menyn vid klick utanför
window.onclick = function (event) {
    var menu = document.getElementById("dropdown");
    var menuButton = document.getElementById("menu-button");

    if (!event.target.matches("#menu-button")) {
        menu.style.display = "none";
        menuButton.innerHTML = "&#9776";
    }
};

// dölj menyn vid resize
window.onresize = function (event) {
    var menu = document.getElementById("dropdown");
    var menuButton = document.getElementById("menu-button");
    menu.style.display = "none";
    menuButton.innerHTML = "&#9776";
};
