document.addEventListener("DOMContentLoaded", function () {


    function initComollegar(startPointLat, startPointLong, endPointLat, endPointLong, endPointName) {
        // Initialize the map centered on the initial start point
        const map = L.map('map', {
            doubleClickZoom: false // Disable double-click zoom
        }).setView([startPointLat, startPointLong], 10);

        // Add a tile layer to the map (using OpenStreetMap tiles)
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);

        // Define the end point from the model
        const endPoint = [endPointLat, endPointLong];

        // Add a marker for the end point
        //L.marker(endPoint).addTo(map).bindPopup("<b>endPointName</b>");

        // Create a routing control without initial waypoints
        const routingControl = L.Routing.control({
            waypoints: [],
            routeWhileDragging: true  // Allow the user to drag the route
        }).addTo(map);

        // Variable to store the starting point marker
        let startMarker;

        // Event listener for map double-clicks to set the starting point
        map.on('dblclick', function (e) {  // Use 'dblclick' instead of 'doubleClick'
            const startPoint = e.latlng; // Get the clicked location

            // Remove existing start marker if it exists
            if (startMarker) {
                map.removeLayer(startMarker);
            }

            // Add a new marker for the start point
            startMarker = L.marker(startPoint).addTo(map).bindPopup("<b>Punto de Inicio</b>").openPopup();

            // Update the routing control with the new start point and fixed end point
            routingControl.setWaypoints([
                L.latLng(startPoint.lat, startPoint.lng), // New Start point
                L.latLng(endPoint[0], endPoint[1])        // Fixed End point
            ]);
        });

        // Funcionalidad de búsqueda con Nominatim
        const searchInput = document.getElementById('searchInput');
        searchInput.addEventListener('keydown', function (event) {
            if (event.key === 'Enter') {
                const query = searchInput.value;
                if (query) {
                    // Llamada a la API de Nominatim
                    fetch(`https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(query)}`)
                        .then(response => response.json())
                        .then(data => {
                            if (data.length > 0) {
                                const result = data[0];
                                const startPoint = [result.lat, result.lon];

                                // Remove existing start marker if it exists
                                if (startMarker) {
                                    map.removeLayer(startMarker);
                                }

                                // Add a new marker for the search result
                                startMarker = L.marker(startPoint).addTo(map).bindPopup(`<b>Punto de Inicio: ${query}</b>`).openPopup();

                                // Update the routing control with the new start point and fixed end point
                                routingControl.setWaypoints([
                                    L.latLng(startPoint[0], startPoint[1]), // New Start point
                                    L.latLng(endPoint[0], endPoint[1])      // Fixed End point
                                ]);

                                // Center map on the search result
                                map.setView(startPoint, 12);
                            } else {
                                alert("No se encontró ninguna ubicación. Intenta otra dirección.");
                            }
                        })
                        .catch(error => {
                            console.error('Error en la búsqueda:', error);
                            alert("Ocurrió un error en la búsqueda. Intenta nuevamente.");
                        });
                }
            }
        });

    }

    if (window.startPointLat && window.startPointLong && window.endPointLat && window.endPointLong && window.endPointName) {
        initComollegar(window.startPointLat, window.startPointLong, window.endPointLat, window.endPointLong, window.endPointName);
    }
});