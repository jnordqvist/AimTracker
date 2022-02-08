// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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