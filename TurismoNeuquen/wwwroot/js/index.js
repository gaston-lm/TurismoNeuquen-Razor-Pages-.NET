document.addEventListener("DOMContentLoaded", function () {
    // Function to initialize the map
    function initMap(pois) {
        const lat = -38.5;
        const lon = -68.0;
        const map = L.map('map').setView([lat, lon], 8);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);

        // Loop through each POI and add it as a marker on the map
        pois.forEach(poi => {
            // Construct the URL manually by using the POI ID
            const detailsUrl = `/UserDetailsPoi?id=${poi.Id}`;

            // Popup content with a link that directs to the details page
            const popupContent = `
                <b>${poi.Name}</b><br>
                ${poi.Description}<br><br>
                <a href="${detailsUrl}" class="btn btn-sm btn-outline-primary">Details</a>
            `;

            // Add the marker with the popup content
            L.marker([poi.Latitude, poi.Longitude])
                .addTo(map)
                .bindPopup(popupContent);
        });
    }

    // Call the function with data passed from Razor page
    // This function expects a variable 'poisData' to be present
    if (window.poisData) {
        initMap(window.poisData, );
    }
});