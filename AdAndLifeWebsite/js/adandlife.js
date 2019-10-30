function openPopup(u) {
	var ww = window.innerWidth || document.documentElement.clientWidth;
	if (ww < 760) location = u; else open(u, '_blank', 'width=600,height=400,resizable=1,top=' + Math.max(0, screen.height / 2 - 300) + ',left=' + Math.max(0, screen.width / 2 - 200))
}
function shareFb(s) { openPopup('https://www.facebook.com/sharer/sharer.php?u=' + encodeURIComponent(s)); }
$(function () {
	$('#hambMenuButton').click(function () {
		$('#topMenu').toggle();
	});
});
