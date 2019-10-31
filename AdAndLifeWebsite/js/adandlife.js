function openPopup(u) {
	var ww = window.innerWidth || document.documentElement.clientWidth;
	if (ww < 760) location = u; else open(u, '_blank', 'width=600,height=400,resizable=1,top=' + Math.max(0, screen.height / 2 - 300) + ',left=' + Math.max(0, screen.width / 2 - 200));
}
function shareFb(s) { openPopup('https://www.facebook.com/sharer/sharer.php?u=' + encodeURIComponent(s)); }
$(function () {
	$('#hambMenuButton').click(function () {
		$('#topMenu').toggle();
	});

	function showClassifiedSearch() {
		$('.search-icon').hide();
		$('.top-nav').hide();
		$('.search-cancel').show();
		$('.search-bar').show().focus();
	}

	function onFontSelected() {
		var size = $(this).attr('data-size');
		document.documentElement.style.fontSize = size + 'px';
		localStorage.setItem('font-size', size);
		var e = $('.dropdown-menu.font-size'); // this reset :active state
		e.replaceWith(e.clone());
		$('.font-change a').click(onFontSelected); // re-attach
	}

	$('.font-change a').click(onFontSelected);

	var fontSize = localStorage.getItem('font-size');
	if (fontSize) {
		document.documentElement.style.fontSize = fontSize + 'px';
	}


	if (location.href.indexOf('classified.aspx') >= 0) {

		if ($(window).width() <= 600) {

			$('.search-icon').click(function () {
				showClassifiedSearch();
			});

			var isSearchActive = $('.search-bar').val() !== '';

			$('.search-cancel').click(function () {
				if (isSearchActive) {
					location.href = '/classified.aspx';
					return;
				}
				$('.search-icon').show();
				$('.top-nav').show();
				$('.search-cancel').hide();
				$('.search-bar').hide();
			});

			if (isSearchActive) {
				showClassifiedSearch();
			} else {
				$('.top-nav').css('visibility', '');
			}

		} else {
			$('.top-nav').css('visibility', '');
		}
		$('.search-cont').css('visibility', '');
	}
});
