function filterAffix() {
  var input = document.getElementById('affix-filter');
  if (!input) return;
  var filter = input.value.toUpperCase();
  var allItems = document.querySelectorAll('#affix ul li');
  var allUls = document.querySelectorAll('#affix ul');
  
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
          if (parent.tagName === 'LI' || parent.tagName === 'UL') {
            parent.style.display = "block";
          }
          parent = parent.parentElement;
        }
      }
    }
  }
}

(function () {
    // 1. Check local storage for theme preference immediately
    const theme = localStorage.getItem('theme');
    if (theme === 'dark' || (!theme && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
        document.body.classList.add('dark-mode');
    }

    // 2. Wait for the DOM to load to inject the toggle button
    document.addEventListener("DOMContentLoaded", function () {
        // Find the navbar container
        const navbar = document.getElementById('navbar');
        if (!navbar) return;

        // Create the toggle container using standard Bootstrap 3 navbar classes
        const toggleContainer = document.createElement('ul');
        toggleContainer.className = 'nav navbar-nav navbar-right';
        
        // Use just the icon for a cleaner look in the header
        toggleContainer.innerHTML = `
            <li>
                <a href="javascript:void(0)" id="theme-toggle" title="Toggle Dark Mode">
                    <span class="glyphicon glyphicon-adjust"></span>
                </a>
            </li>
        `;

        // Find the search form. Standard DocFX templates use id="search"
        const searchForm = document.getElementById('search');
        
        // Inject it. Because .navbar-right uses float: right, inserting it *before* // the search form in the DOM actually places it to the *right* visually.
        if (searchForm) {
            searchForm.parentNode.insertBefore(toggleContainer, searchForm);
        } else {
            navbar.appendChild(toggleContainer);
        }

        // Add click event listener
        const toggleBtn = document.getElementById('theme-toggle');
        toggleBtn.addEventListener('click', function () {
            document.body.classList.toggle('dark-mode');
            
            // Save preference
            if (document.body.classList.contains('dark-mode')) {
                localStorage.setItem('theme', 'dark');
            } else {
                localStorage.setItem('theme', 'light');
            }
        });
    });
})();