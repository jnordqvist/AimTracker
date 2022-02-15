
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

/* Get all elements with class="close" */
var closebtns = document.getElementsByClassName("close");
var i;

/* Loop through the elements, and hide the parent, when clicked on */
for (i = 0; i < closebtns.length; i++) {
    closebtns[i].addEventListener("click", function () {
        this.parentElement.style.display = 'none';
    });
}

var xValues = [100, 200, 300, 400, 500, 600, 700, 800, 900, 1000];

let dataValues = [860, 1140, 1060, 1060, 1070, 1110, 1330, 2210, 7830, 2478]

new Chart("lineGraph", {
    type: "line",
    data: {
        labels: xValues,
        datasets: [{
            data: dataValues,
            borderColor: "red",
            fill: false
        }]
    },
    options: {
        legend: { display: false }
    }
});

//, {
//    data: [1600, 1700, 1700, 1900, 2000, 2700, 4000, 5000, 6000, 7000],
//        borderColor: "green",
//            fill: false
//}, {
//    data: [300, 700, 2000, 5000, 6000, 4000, 2000, 1000, 200, 100],
//        borderColor: "blue",
//            fill: false
//}



