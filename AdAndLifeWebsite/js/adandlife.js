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
		$('.rubric-menu').hide();
		$('.search-cancel').show();
		$('.search-bar').show().focus();
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
				$('.rubric-menu').show();
				$('.search-cancel').hide();
				$('.search-bar').hide();
			});

			if (isSearchActive) {
				showClassifiedSearch();
			} else {
				$('.rubric-menu').css('visibility', '');
			}

		} else {
			$('.rubric-menu').css('visibility', '');
		}
		$('.search-cont').css('visibility', '');
	}
});
