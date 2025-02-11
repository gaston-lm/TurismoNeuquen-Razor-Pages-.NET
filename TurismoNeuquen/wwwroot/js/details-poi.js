﻿document.addEventListener("DOMContentLoaded", function () {
    function initDetails(poiData) {
        // Get the POI latitude and longitude from the Razor model
        const poiLat = poiData.Latitude;
        const poiLng = poiData.Longitude;

        // Initialize the map centered on the POI's location
        const map = L.map('poiMap').setView([poiLat, poiLng], 13);

        // Add OpenStreetMap tiles to the map
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);

        // Add a marker at the POI location with a popup containing the POI name
        L.marker([poiLat, poiLng])
            .addTo(map)
            .bindPopup(`<b>${poi.Name}</b><br>${poi.Description}`)
            .openPopup();
    }

    if (window.poiData) {
        initDetails(window.poiData);
    }

});