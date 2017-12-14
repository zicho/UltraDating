$("#menu-button").click(function () {
    var menu = document.getElementById("dropdown");
    var menuButton = document.getElementById("menu-button");
    if (menu.style.display === "none") {
        menu.style.display = "block";
        menuButton.innerHTML = "&#x274c;";
    } else {
        menu.style.display = "none";
        menuButton.innerHTML = "&#9776";
    }

    var menuItems = [];

    $("#main-menu a").each(function () {
        var el = $(this);
        menuItems.push(el);
        //alert(el.text());
    });
    menuItems.splice(-1, 1);

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

window.onclick = function (event) {
    var menu = document.getElementById("dropdown");
    var menuButton = document.getElementById("menu-button");

    if (!event.target.matches("#menu-button")) {
        menu.style.display = "none";
        menuButton.innerHTML = "&#9776";
    }
};

window.onresize = function (event) {
    var menu = document.getElementById("dropdown");
    var menuButton = document.getElementById("menu-button");
    menu.style.display = "none";
    menuButton.innerHTML = "&#9776";
};
