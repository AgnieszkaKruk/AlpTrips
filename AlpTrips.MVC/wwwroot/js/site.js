function showSubMountainRanges(selectElement) {
    var subMountainRangeContainer = document.getElementById("subMountainRangeContainer");
    var subMountainRangeContainer2 = document.getElementById("subMountainRangeContainer2");
    var subMountainRangeContainer3 = document.getElementById("subMountainRangeContainer3");
    var subMountainRangeContainer4 = document.getElementById("subMountainRangeContainer4");
    var selectedMountainRange = selectElement.value;

    if (selectedMountainRange === "Alpy Wschodnie") {
        subMountainRangeContainer.style.display = "block";
        subMountainRangeContainer2.style.display = "none";
        subMountainRangeContainer3.style.display = "none";
        subMountainRangeContainer4.style.display = "none";
    } else if (selectedMountainRange === "Alpy Centralne") {
        subMountainRangeContainer.style.display = "none";
        subMountainRangeContainer2.style.display = "block";
        subMountainRangeContainer3.style.display = "none";
        subMountainRangeContainer4.style.display = "none";
    } else if (selectedMountainRange === "Alpy Zachodnie") {
        subMountainRangeContainer.style.display = "none";
        subMountainRangeContainer2.style.display = "none";
        subMountainRangeContainer3.style.display = "block";
        subMountainRangeContainer4.style.display = "none";
    } else if (selectedMountainRange === "Alpy Południowe") {
        subMountainRangeContainer.style.display = "none";
        subMountainRangeContainer2.style.display = "none";
        subMountainRangeContainer3.style.display = "none";
        subMountainRangeContainer4.style.display = "block";
    } else {
        subMountainRangeContainer.style.display = "none";
        subMountainRangeContainer2.style.display = "none";
        subMountainRangeContainer3.style.display = "none";
        subMountainRangeContainer4.style.display = "none";
    }
}

function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 0, lng: 0 },
        zoom: 8
    });

    var marker = new google.maps.Marker({
        map: map
    });

    var input = document.getElementById('location-input');
    var autocomplete = new google.maps.places.Autocomplete(input);

    autocomplete.addListener('place_changed', function () {
        var place = autocomplete.getPlace();
        if (place.geometry && place.geometry.location) {
            var location = place.geometry.location;
            map.setCenter(location);
            marker.setPosition(location);
        }
    });
}

function FillInput() {
    console.log("FillInput() function has been called.");
    var nameInput = document.getElementById("name-input");
    var locationInput = document.getElementById("location-input");

    nameInput.addEventListener("input", function () {
        locationInput.value = nameInput.value;
    });
}






