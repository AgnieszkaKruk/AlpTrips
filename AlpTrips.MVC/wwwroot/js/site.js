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

