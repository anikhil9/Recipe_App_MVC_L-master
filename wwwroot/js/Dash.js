document.getElementById('recipe-form').addEventListener('submit', function(e) {
    e.preventDefault();
    const name = document.getElementById('recipe-name').value;
    const ingredients = document.getElementById('ingredients').value;
    const steps = document.getElementById('steps').value;
    addRecipe(name, ingredients, steps);
    this.reset();
});

function addRecipe(name, ingredients, steps) {
    const list = document.getElementById('recipe-list');
    const li = document.createElement('li');
    li.className = 'recipe-item';
    li.innerHTML = `
        <strong>${name}</strong>
        <p>Ingredients: ${ingredients}</p>
        <p>Steps: ${steps}</p>
        <button class="edit-btn" onclick="editRecipe(this)">Edit</button>
        <button class="delete-btn" onclick="deleteRecipe(this)">Delete</button>
    `;
    list.appendChild(li);
}

function editRecipe(btn) {
    const li = btn.parentNode;
    const name = prompt("Update the recipe name", li.querySelector('strong').textContent);
    const ingredients = prompt("Update the ingredients", li.querySelectorAll('p')[0].textContent.substring(12));
    const steps = prompt("Update the steps", li.querySelectorAll('p')[1].textContent.substring(7));
    if (name) li.querySelector('strong').textContent = name;
    if (ingredients) li.querySelectorAll('p')[0].textContent = "Ingredients: " + ingredients;
    if (steps) li.querySelectorAll('p')[1].textContent = "Steps: " + steps;
}

function deleteRecipe(btn) {
    if (confirm('Are you sure you want to delete this recipe?')) {
        btn.parentNode.remove();
    }
}