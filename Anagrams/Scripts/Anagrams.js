$(function () {
	$('input#Word').focus();
	$('#anagramlookup form').submit(function (event) {
		event.preventDefault();
		$('#message').html('');
		$('#result ul').html('');
		$.ajax({
			type: "POST",
			url: this.action,
			data: $(this).serialize(),
			success: function (json) {
				if (json.Exception) {
					$('#message').html(json.Exception.Message);
				}
				var html = '';
				$.each(json.Anagrams, function (key, value) {
					html = html + '<li>' + value + '</li>';
				});
				$('#result ul').html(html);
			}
		});
	});
});