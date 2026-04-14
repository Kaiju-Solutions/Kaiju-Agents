function filterAffix() {
  var input = document.getElementById('affix-filter');
  if (!input) return;
  var filter = input.value.toUpperCase();
  var allItems = document.querySelectorAll('#affix ul li');
  var allUls = document.querySelectorAll('#affix ul');
  
  if (filter === "") {
    for (var i = 0; i < allItems.length; i++) {
      allItems[i].style.display = "";
    }
    for (var i = 0; i < allUls.length; i++) {
      allUls[i].style.display = "";
    }
    return;
  }

  for (var i = 0; i < allItems.length; i++) {
    allItems[i].style.display = "none";
  }
  for (var i = 0; i < allUls.length; i++) {
    allUls[i].style.display = "none";
  }

  for (var i = 0; i < allItems.length; i++) {
    var item = allItems[i];
    var a = item.querySelector('a');
    if (a) {
      var txtValue = a.textContent || a.innerText;
      if (txtValue.toUpperCase().indexOf(filter) > -1) {
        item.style.display = "block";
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
    const theme = localStorage.getItem('theme');
    if (theme === 'dark' || (!theme && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
        document.body.classList.add('dark-mode');
    }

    document.addEventListener("DOMContentLoaded", function () {
        const navbar = document.getElementById('navbar');
        if (!navbar) return;

        const toggleContainer = document.createElement('div');
        toggleContainer.className = 'navbar-right';
        
        toggleContainer.innerHTML = `
            <a href="#" id="theme-toggle" title="Toggle Dark Mode" style="display: inline-block; padding: 15px; text-decoration: none;">
                <span class="glyphicon glyphicon-adjust"></span>
            </a>
        `;

        const searchForm = document.getElementById('search');
        
        if (searchForm) {
            searchForm.parentNode.insertBefore(toggleContainer, searchForm);
        } else {
            navbar.appendChild(toggleContainer);
        }

        const toggleBtn = document.getElementById('theme-toggle');
        toggleBtn.addEventListener('click', function (e) {
            // Stop the link from redirecting the page
            e.preventDefault();
            
            document.body.classList.toggle('dark-mode');
            
            if (document.body.classList.contains('dark-mode')) {
                localStorage.setItem('theme', 'dark');
            } else {
                localStorage.setItem('theme', 'light');
            }
        });
    });
})();