﻿
// Declaration of necessary variables 
let topnav = document.getElementById("myLinks");
let mediaquery = window.matchMedia("(min-width: 1000px)")

displayLinks(mediaquery) // Calls function on runtime

mediaquery.addListener(displayLinks) // Attach listener function on state changes

// Show and hide links depending on topnav style 
function myFunction() {
 
    if (topnav.style.display === "block") {
        topnav.style.display = "none";

    } else {
        topnav.style.display = "block";
    }
}

// Displays links when media query is equal to 1000px or > 
function displayLinks(mediaquery) {
    if (mediaquery.matches) { 
        topnav.style.display = "flex";
    } else {
        topnav.style.display = "none";
    }
}

/*Start polar scatter chart*/

function getrandom(num, mul) {
    var value = []
    for (i = 0; i <= num; i++) {
        rand = Math.random() * mul;
        value.push(rand);
    }
    return value;
}

var x = -85.9962
var y = 54.444557
var coords = cartesian2Polar(x, y)

function cartesian2Polar(x, y) {
    distance = Math.sqrt(x * x + y * y)
    radians = Math.atan2(y, x) 
    polarCoor = { distance: distance, radians: radians }
    return polarCoor
}

var trace1 = {
    r: [coords.radians],
    t: [coords.distance],
    mode: 'markers',
    name: 'Serie 1',
    marker: {
        color: 'rgb(27,158,119)',
        size: 110,
        line: { color: 'white' },
        opacity: 0.7
    },
    type: 'scatter'
};

/*skapa nya traces, stoppa in i datalistan och byt ut trace mot data i plot() 
 * för att visualisera fler saker i andra färger och med andra labels*/
/*var data = [trace1];*/

var layout = {
    title: 'Serie X',
    font: { size: 15 },
    plot_bgcolor: 'rgb(223, 223, 223)',
    direction: 'clockwise'
};
console.log("test")
Plotly.plot('myDiv', [trace1], layout);

/*End polar scatter chart */

/* Get all elements with class="close" */
var closebtns = document.getElementsByClassName("close");
var i;

/* Loop through the elements, and hide the parent, when clicked on */
for (i = 0; i < closebtns.length; i++) {
    closebtns[i].addEventListener("click", function () {
        this.parentElement.style.display = 'none';
    });
}

var xValues = [1, 2, 3, 4, 5];
var uri = '/api/values';

getDataValues();

function getDataValues() {

    $.getJSON(uri + "?id=" +32)
        .done(function (data) {
            new Chart("lineGraph", {
                type: "line",
                label:'Pulse at time of shot',
                data: {
                    labels: xValues,
                    datasets: [{
                        data: data,
                        borderColor: "red",
                        fill: false
                    }]
                },
                options: {
                    legend: { display: false }
                }
            })
        });

}




//, {
//    data: [1600, 1700, 1700, 1900, 2000, 2700, 4000, 5000, 6000, 7000],
//        borderColor: "green",
//            fill: false
//}, {
//    data: [300, 700, 2000, 5000, 6000, 4000, 2000, 1000, 200, 100],
//        borderColor: "blue",
//            fill: false
//}



