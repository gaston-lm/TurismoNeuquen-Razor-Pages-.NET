document.addEventListener("DOMContentLoaded", function () {
    // Set initial map view over Neuquén, Argentina
    const lat = -38.5;
    const lon = -68.0;
    const selectMap = L.map('selectMap').setView([lat, lon], 8);

    // Add OpenStreetMap tiles
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(selectMap);

    // Variable to store the marker
    let selectionMarker;

    // Handle map clicks to update coordinates
    selectMap.on('click', function (e) {
        const { lat, lng } = e.latlng;

        // Update input fields with clicked coordinates
        document.getElementById('lat').value = lat;
        document.getElementById('lng').value = lng;

        // Add or move marker to clicked location
        if (selectionMarker) {
            selectionMarker.setLatLng([lat, lng]);
        } else {
            selectionMarker = L.marker([lat, lng]).addTo(selectMap);
        }
    });
});

function showFields() {
    // Get the radio button elements
    const attractionRadio = document.getElementById("optionAttraction");
    const eventRadio = document.getElementById("optionEvent");

    // Get the fieldsets for attraction and event
    const attractionFields = document.getElementById("attractionFields");
    const eventFields = document.getElementById("eventFields");

    // Check if radio buttons are checked and show/hide fields accordingly
    if (attractionRadio.checked) {
        attractionFields.style.display = "block";
        eventFields.style.display = "none";
        clearEventFields(); // Clear event fields if switching to attraction

        // Set required fields for attraction
        setRequiredFields(attractionFields, true);
        setRequiredFields(eventFields, false);
    } else if (eventRadio.checked) {
        attractionFields.style.display = "none";
        eventFields.style.display = "block";
        clearAttractionFields(); // Clear attraction fields if switching to event

        // Set required fields for event
        setRequiredFields(attractionFields, false);
        setRequiredFields(eventFields, true);
    }
}

function setRequiredFields(container, isRequired) {
    const inputs = container.querySelectorAll('input[required]');
    inputs.forEach(input => {
        if (isRequired) {
            input.setAttribute('required', 'required'); // Set required
        } else {
            input.removeAttribute('required'); // Remove required
        }
    });
}

function clearEventFields() {
    const eventDateInput = document.querySelector('input[name="EventDate"]');
    const locationInput = document.querySelector('input[name="Location"]');

    if (eventDateInput) {
        eventDateInput.value = ""; // Clear value
    }
    if (locationInput) {
        locationInput.value = ""; // Clear value
    }
}

function clearAttractionFields() {
    const openingTimeInput = document.querySelector('input[name="OpeningTime"]');
    const closingTimeInput = document.querySelector('input[name="ClosingTime"]');
    const openDaysInput = document.getElementById('OpenDays');

    if (openingTimeInput) {
        openingTimeInput.value = ""; // Clear value
    }
    if (closingTimeInput) {
        closingTimeInput.value = ""; // Clear value
    }
    if (openDaysInput) {
        openDaysInput.value = ""; // Clear open days
    }

    // Clear the day checkboxes
    const checkboxes = document.querySelectorAll('.dayCheckbox');
    checkboxes.forEach(checkbox => {
        checkbox.checked = false; // Uncheck all checkboxes
    });
}

// Initial call to set the correct fields when the page loads
showFields();

function updateOpenDays() {
    const checkboxes = document.querySelectorAll('.dayCheckbox');
    let openDaysBinary = '';

    checkboxes.forEach((checkbox, index) => {
        openDaysBinary += checkbox.checked ? '1' : '0';
    });

    document.getElementById('OpenDays').value = openDaysBinary;
}