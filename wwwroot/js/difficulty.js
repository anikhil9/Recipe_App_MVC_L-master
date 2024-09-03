document.getElementById('difficulty-form').addEventListener('submit', function (e) {
    e.preventDefault();
    const recipeName = document.getElementById('recipe-name').value;
    const difficulty = parseInt(document.getElementById('difficulty').value); // Convert to integer for validation

    // Check if difficulty is within the allowed range
    if (difficulty < 1 || difficulty > 10 || isNaN(difficulty)) {
        alert("Please enter a difficulty level between 1 and 10.");
        return; // Stop the form submission if the validation fails
    }

    addDifficulty(recipeName, difficulty);
    this.reset();
});

function addDifficulty(name, difficulty) {
    const list = document.getElementById('difficulties-list');
    const li = document.createElement('li');
    li.innerHTML = `${name} - Difficulty: ${difficulty} <button onclick="editDifficulty(this)">Edit</button> <button onclick="deleteDifficulty(this)">Delete</button>`;
    list.appendChild(li);
}

function editDifficulty(btn) {
    const li = btn.parentNode;
    const parts = li.textContent.split(' - Difficulty: ');
    const currentDifficulty = parts[1].trim();
    const newDifficulty = prompt("Update the difficulty (1-10)", currentDifficulty);

    // Convert and validate the new difficulty
    const validDifficulty = parseInt(newDifficulty);
    if (!validDifficulty || validDifficulty < 1 || validDifficulty > 10) {
        alert('Please enter a valid difficulty between 1 and 10.');
        return; // Stop the update if validation fails
    }

    li.innerHTML = `${parts[0]} - Difficulty: ${validDifficulty} <button onclick="editDifficulty(this)">Edit</button> <button onclick="deleteDifficulty(this)">Delete</button>`;
}

function deleteDifficulty(btn) {
    if (confirm('Are you sure you want to delete this difficulty?')) {
        btn.parentNode.remove();
    }
}
