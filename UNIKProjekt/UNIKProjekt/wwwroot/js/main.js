function ToggleSlide(e, id) {
    e.preventDefault();

    var cont = document.getElementById(id);
    var arrow = document.getElementById(id + '-arrow');
    cont.classList.toggle('on');

    if(arrow != null)
        arrow.classList.toggle('Open');
}

function CloseAlert(e, id) {
    e.preventDefault();

    var el = document.getElementById(id);

    if(el != undefined) {
        el.classList.add('fadeOut');
        setTimeout(function() { 
            el.remove();
        }, 400);
    } else {
        console.log("Alert element couldn't be found.");
    }
}

function Search(e) {
    e.preventDefault();

    var s = document.getElementById("s");
    var itemCount = document.getElementById("itemCount");
    var items = document.getElementsByClassName("searchItem");
    var curItems = 0;

    for(var i = 0; i < items.length; i++) {
        var address = items[i].dataset.address.toLowerCase();
        var city = items[i].dataset.city.toLowerCase();

        if(address.includes(s.value.toLowerCase()) || city.includes(s.value.toLowerCase())) {
            items[i].style.display = "block";

            curItems++;
        } else {
            items[i].style.display = "none";
        }
    }

    itemCount.innerHTML = curItems;
}

function UpdateSorting(e) {
    e.preventDefault();

    var items = document.getElementsByClassName("searchItem");
    var others = document.getElementById("criteriaForm").elements;
    var items = document.getElementsByClassName("searchItem");

    for(var i = 0; i < others.length; i++) {
        for(var o = 0; o < items.length; o++) {
            var key = others[i].dataset.key;
            
            if(items[o].getAttribute("data-" + key)) {
                var res = document.querySelector("[data-" + key + "=" + others[i].checked + "]");
                console.log(items[o].getAttribute("data-" + key))
            }
            
            if(items[o].getAttribute("data-" + key)) {
                if(others[i].checked) {
                    if(items[o].getAttribute("data-" + key).toLowerCase() == "true") {
                        items[o].style.display = "block";
                    } else {
                        items[o].style.display = "none";
                    }
                } else {
                    items[o].style.display = "block";
                }
            }
        }
    }

    itemCount.innerHTML = ":)";
}