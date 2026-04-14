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
        // Find the navbar
        const navbar = document.querySelector('#autocollapse .navbar-collapse');
        if (!navbar) return;

        // Create the toggle container
        const toggleContainer = document.createElement('ul');
        toggleContainer.className = 'nav navbar-nav navbar-right';
        toggleContainer.innerHTML = `
            <li>
                <a href="javascript:void(0)" id="theme-toggle" title="Toggle Dark Mode" style="font-size: 18px; line-height: 20px;">
                    <span class="glyphicon glyphicon-adjust"></span>
                </a>
            </li>
        `;

        // Append the toggle to the navbar
        navbar.appendChild(toggleContainer);

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