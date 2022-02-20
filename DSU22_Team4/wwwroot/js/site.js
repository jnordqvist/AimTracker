
// Declaration of necessary variables
let topnav = document.getElementById("myLinks");
let mediaquery = window.matchMedia("(min-width: 1000px)")
let intensity = document.getElementById("intensity");
//let btnOkDate = document.getElementById("btnOkDate");
//btnOkDate.addEventListener("click", getTrainingSessionFromDate);

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
// change color on button depending on hit.
document.querySelectorAll('#shot').forEach(button => {
    if (button.textContent === "hit") {
        button.style.background = "white";
        button.style.color = "white";

    }
});

//hover on hitbutton
document.querySelectorAll('#shot').forEach(button => {
    button.addEventListener("mouseover", function () {
        if (button.textContent === "hit") { button.style.color = "black"; }
    })
});

//hover out on hit button
document.querySelectorAll('#shot').forEach(button => {
    button.addEventListener("mouseout", function () {
        if (button.textContent === "hit") { button.style.color = "white"; }
    })
});




$("p.intensity").each(function () {
    $(this).html() < 50 ? $(this).css('background', 'green') : null;

    ($(this).html() >= 50 && $(this).html() < 80) ? $(this).css('background', 'yellow') : null;

    $(this).html() >= 80 ? $(this).css('background', 'red') : null;
});

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

$(document).ready(function () {
    const monthNames = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];
    let qntYears = 4; /*Lägg in kod för att läsa in hur många år atleten har varit aktiv?*/
    let selectYear = $("#year");
    let selectMonth = $("#month");
    let selectDay = $("#day");
    let currentYear = new Date().getFullYear();

    for (var y = 0; y < qntYears; y++) {
        let date = new Date(currentYear);
        let yearElem = document.createElement("option");
        yearElem.value = currentYear
        yearElem.textContent = currentYear;
        selectYear.append(yearElem);
        currentYear--;
    }

    for (var m = 0; m < 12; m++) {
        let month = monthNames[m];
        let monthElem = document.createElement("option");
        monthElem.value = m;
        monthElem.textContent = month;
        selectMonth.append(monthElem);
    }

    var d = new Date();
    var month = d.getMonth();
    var year = d.getFullYear();
    var day = d.getDate();

    selectYear.val(year);
    selectYear.on("change", AdjustDays);
    selectMonth.val(month);
    selectMonth.on("change", AdjustDays);


    

    AdjustDays();
    selectDay.val(day)

    function AdjustDays() {
        var year = selectYear.val();
        var month = parseInt(selectMonth.val()) + 1;
        selectDay.empty();

        var days = new Date(year, month, 0).getDate();

        for (var d = 1; d <= days; d++) {
            var dayElem = document.createElement("option");
            dayElem.value = d;
            dayElem.textContent = d;
            selectDay.append(dayElem);
        }
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



