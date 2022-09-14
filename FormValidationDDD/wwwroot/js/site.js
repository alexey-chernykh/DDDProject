"use strict";

let anketa = document.getElementById("anketa");

document.forms[0].onsubmit = function (event) {

    if (!event) event = window.event;

    let email = document.getElementById("email").value;
    let name = document.getElementById("name").value;
    let country = document.getElementById("getcountry").value;

    if (name == "") {

        alert("Нужно ввести имя!")
        return event.returnValue = false;

    } else if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(email) == false) {

        alert("Неверно введенный Email-адрес!")
        return event.returnValue = false;

    } else if (country == "") {

        alert("Выберите страну!")
        return event.returnValue = false;

    } else {

        alert("Данные успешно отправлены на обработку.");
        return event.returnValue = false;

    }
};
