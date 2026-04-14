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
        // Find the existing search form instead of the entire navbar collapse
        const searchForm = document.getElementById('search');
        if (!searchForm) return;

        // Create the toggle container to mimic a Bootstrap form-group
        const toggleContainer = document.createElement('div');
        toggleContainer.className = 'form-group';
        
        // Inline styles to perfectly align it with the search bar
        toggleContainer.style.display = 'inline-block';
        toggleContainer.style.verticalAlign = 'middle';
        toggleContainer.style.marginRight = '15px'; 

        toggleContainer.innerHTML = `
            <a href="javascript:void(0)" id="theme-toggle" title="Toggle Dark Mode" style="color: #999; font-size: 18px; text-decoration: none; line-height: 1;">
                <span class="glyphicon glyphicon-adjust"></span>
            </a>
        `;

        // Prepend it so it sits to the left of the search input
        searchForm.insertBefore(toggleContainer, searchForm.firstChild);

        // Add click event listener
        const toggleBtn = document.getElementById('theme-toggle');
        
        // Add a nice hover effect
        toggleBtn.addEventListener('mouseenter', () => toggleBtn.style.color = document.body.classList.contains('dark-mode') ? '#fff' : '#333');
        toggleBtn.addEventListener('mouseleave', () => toggleBtn.style.color = '#999');

        toggleBtn.addEventListener('click', function () {
            document.body.classList.toggle('dark-mode');
            
            // Re-apply hover color based on new state
            toggleBtn.style.color = document.body.classList.contains('dark-mode') ? '#fff' : '#333';
            
            // Save preference
            if (document.body.classList.contains('dark-mode')) {
                localStorage.setItem('theme', 'dark');
            } else {
                localStorage.setItem('theme', 'light');
            }
        });
    });
})();