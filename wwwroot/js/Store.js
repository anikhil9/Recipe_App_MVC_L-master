document.addEventListener('DOMContentLoaded', function() {
    const stores = [
        { name: "Azure Bistro", address: "1010 Market St", state: "Maharashtra" },
        { name: "Orchid Eatery", address: "202 Pine Ln", state: "Kerala" },
        { name: "Ruby Lounge", address: "304 West Ave", state: "Tamil Nadu" },
        { name: "Emerald Greens", address: "450 Vine St", state: "Karnataka" },
        { name: "Golden Spoon", address: "123 Oak Rd", state: "Telangana" },
        { name: "Copper Pot", address: "222 Maple Ave", state: "Gujarat" },
        { name: "Silver Fork", address: "556 Elm Dr", state: "Rajasthan" },
        { name: "Platinum Grill", address: "789 Birch Pl", state: "West Bengal" },
        { name: "Diamond Deli", address: "321 Cedar Blvd", state: "Odisha" },
        { name: "Garnet Garden", address: "654 Spruce Way", state: "Punjab" },
        { name: "Sapphire Sweets", address: "908 River Rd", state: "Haryana" },
        { name: "Amber Alcove", address: "147 Lakeview Dr", state: "Uttar Pradesh" },
        { name: "Onyx Oven", address: "234 Peachtree St", state: "Madhya Pradesh" },
        { name: "Topaz Tavern", address: "567 Broadway Ave", state: "Bihar" },
        { name: "Jade Junction", address: "103 Sunset Blvd", state: "Goa" },
        { name: "Nawabi", address: "14204 Cyber PL", state: "Andhra Pradesh" },
    ];

    const searchBar = document.getElementById('searchBar');
    const tableBody = document.querySelector('#storeTable tbody');

    function updateTable(filteredStores) {
        const rows = filteredStores.map(store => 
            `<tr>
                <td>${store.name}</td>
                <td>${store.address}</td>
                <td>${store.state}</td>
            </tr>`
        ).join('');
        tableBody.innerHTML = rows;
    }

    searchBar.addEventListener('input', (e) => {
        const text = e.target.value.toLowerCase();
        const filteredStores = stores.filter(store => store.name.toLowerCase().includes(text));
        updateTable(filteredStores);
    });

    updateTable(stores); // Initialize the table
});
