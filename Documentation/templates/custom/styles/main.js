/**
 * Filters the in-page table of contents (affix) based on user input.
 */
function filterAffix() {
  var input = document.getElementById('affix-filter');
  if (!input) return;
  
  var filter = input.value.toUpperCase();
  // Target both standard BS3/BS4 and BS5 (modern template) structures
  var allItems = document.querySelectorAll('#affix .nav-item, #affix li');
  var allUls = document.querySelectorAll('#affix .nav, #affix ul');
  
  // Initially show everything if filter is empty
  if (filter === "") {
    for (var i = 0; i < allItems.length; i++) {
      allItems[i].style.display = "";
    }
    for (var i = 0; i < allUls.length; i++) {
      allUls[i].style.display = "";
    }
    return;
  }

  // Hide everything first
  for (var i = 0; i < allItems.length; i++) {
    allItems[i].style.display = "none";
  }
  for (var i = 0; i < allUls.length; i++) {
    allUls[i].style.display = "none";
  }

  // Show matching items and their parents
  for (var i = 0; i < allItems.length; i++) {
    var item = allItems[i];
    var a = item.querySelector('a');
    if (a) {
      var txtValue = a.textContent || a.innerText;
      if (txtValue.toUpperCase().indexOf(filter) > -1) {
        // Show this item
        item.style.display = "block";
        // Show all parent li and ul elements to ensure the path to the matching item is visible
        var parent = item.parentElement;
        while (parent && parent.id !== 'affix') {
          if (parent.tagName === 'LI' || parent.tagName === 'UL' || parent.classList.contains('nav') || parent.classList.contains('nav-item')) {
            parent.style.display = "block";
          }
          parent = parent.parentElement;
        }
      }
    }
  }
}
