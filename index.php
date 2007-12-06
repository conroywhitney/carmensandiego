<?php require("image_dates.php"); ?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  <head>
    <title>GATech CS4440 - Carmen Sandiego</title>

    <!-- Set up the GMap -->
    <script src="http://maps.google.com/maps?file=api&v=1&key=ABQIAAAAFZtAt1faYiXlDfkUEP-iVRS8ewY-I6_csZPw9RwV-6NNCZKMixRCNBt5R5ra-AOlWAVae1xSuR5Tww" type="text/javascript">
    </script>

	<!-- Prototype for Sliders -->
	<script src="javascripts/prototype.js" type="text/javascript"></script>
	<script src="javascripts/slider.js" type="text/javascript"></script>
	<!-- Style for Sliders -->
	<style type="text/css" media="screen" >
		/* put the track and the right rounded edge on the track */
		#track {
			background: transparent url(images/slider-images-track.png) repeat-x top left;
		}

		.handle {
			width: 19px; height: 20px;
			float: left;
		}
	</style>
  </head>

<body onunload="GUnload()">
<center>
	<!-- GMap -->
	<table border=1>
	<tr>
		<td>
			<div id="map" style="width: 800px; height: 600px"></div>
		</td>
		<td width = 150 valign="top" style="text-decoration: underline; color: #4444ff;">
			<div id="side_bar"></div>
		</td>
	</tr>
	</table>

	<br /><br />

	<!-- Sliders -->
	<div id="track" style="width:500px; height:9px;">
		<div id="handle1" class="handle"><img src="images/slider-images-handle.png" /></div>
		<div id="handle2" class="handle"><img src="images/slider-images-handle.png" /></div>
	</div>

	<br /><br />

	<p id="date_range">&nbsp;</p>
	<p id="status">&nbsp;</p>

</center>

    <noscript><b>JavaScript must be enabled in order for you to use Google Maps.</b> 
      However, it seems JavaScript is either disabled or not supported by your browser. 
      To view Google Maps, enable JavaScript by changing your browser options, and then 
      try again.
    </noscript>


    <script type="text/javascript">

    //<![CDATA[

    if (GBrowserIsCompatible()) {
      // this variable will collect the html which will eventualkly be placed in the side_bar
      var side_bar_html = "";
    
      // arrays to hold copies of the markers used by the side_bar
      // because the function closure trick doesnt work there
      var gmarkers = [];
      var i = 0;

	/* Set up initial start/end dates; these will change with slider */
	var start_date = '2007-10-24';
	var end_date = '2007-11-03';

      // A function to create the marker and set up the event window
      function createMarker(point,name,html) {
        var marker = new GMarker(point);
        GEvent.addListener(marker, "click", function() {
          marker.openInfoWindowHtml(html);
        });
        // save the info we need to use later for the side_bar
        gmarkers[i] = marker;
        // add a line to the side_bar html
        side_bar_html += '<a href="javascript:myclick(' + i + ')">' + name + '</a><br>';
        i++;
        return marker;
      }


      // This function picks up the click and opens the corresponding info window
      function myclick(i) {
        GEvent.trigger(gmarkers[i], "click");
      }

	// create the map with controls (zoom, etc)
	var map = new GMap2(document.getElementById("map"));
	map.addControl(new GLargeMapControl());
	map.addControl(new GMapTypeControl());

	/* set default center and zoom */
	map.setCenter(new GLatLng(33.776474, -84.397318), 14);

	/* add a listener to the "zooming" function so can monitor when they zoom in/out */
	GEvent.addListener(map, "zoomend", function() { refresh() });

	<!-- THIS IS THE IMPORTANT AJAXy PART  -->

	/* send request to our PHP AJAX page to get zoom/start/end */
	function sendRequest(start, end) {

		/* use GMap's awesome AJAX wrapper */
		var request = GXmlHttp.create();

		/* construct URL we'll be pinging with zoom/start/end */
		var url = "markers.php?start=" + start + "&end=" + end;

		/* set HTTP-type, URL, ?something? of request */
		request.open("GET", url, true);

		/* define function to execute after receiving info from PHP script */
		request.onreadystatechange = function() {
			if (request.readyState == 4) {
				/* reset the side-bar info */
				side_bar_html = '';

				/* clear all the markers currently on the map */
				map.clearOverlays();

				var xmlDoc = GXml.parse(request.responseText);
				/* parse incoming XML doc and obtain "marker" elements */
				var markers = xmlDoc.documentElement.getElementsByTagName("marker");
	          
				/* loop through and get attributes of "marker" */
				for (var i = 0; i < markers.length; i++) {
					/* create new GPoint (GLatLng) from marker's latlong info */
					var lat = parseFloat(markers[i].getAttribute("lat"));
					var lng = parseFloat(markers[i].getAttribute("lng"));
					var point = new GLatLng(lat,lng);

					/* get side-view HTML content for "marker" */
					var html = markers[i].getAttribute("html");

					/* get popup-label content for "marker" */
					var label = markers[i].getAttribute("label");

					/* use function to create new GMap marker given element's info */
					var marker = createMarker(point,label,html);

					/* add new GMap marker to map */
					map.addOverlay(marker);
				}

				/* add "marker"s info to side_bar for easy browse-click */
				document.getElementById("side_bar").innerHTML = side_bar_html;

				/* update status div */
				$('status').innerHTML = "";
			}
		}
		/* send off AJAX request we've constructed */
		request.send(null);

		return false;

	}

	<!-- END IMPORTANT AJAXy PART -->

	/* called by any DHTML element that necessitates a change */
	function refresh() {
		return sendRequest(getStart(), getEnd());
	}

	/* get the start-time */
	function getStart() {
		return start_date;
	}

	/* get the end-time */
	function getEnd() {
		return end_date;
	}

	/* render our map for the first time */
	refresh();

    } else {
      alert("Sorry, the Google Maps API is not compatible with this browser");
    }

    // Copyright information ----------------------------
    // This Javascript is based on code provided by the
    // Blackpool Community Church Javascript Team
    // http://www.commchurch.freeserve.co.uk/   
    // http://econym.googlepages.com/index.htm
    // ------------------------ End copyright information
    //]]>
    </script>

	<script type="text/javascript" language="javascript">
	// <![CDATA[
		var num_dates = <?php echo $num_dates; ?>;
		var dates = <?php echo $dates_js; ?>;

		var handles = [$('handle1'), $('handle2')];
		var values = <?php echo $values_count_js; ?>;

		// horizontal slider control left
		new Control.Slider(handles, 'track', 
			{
				range: $R(0,num_dates, false),
				sliderValue: [0, num_dates], // First handle at earliest date (0), 2nd at max date (num_dates)
				restricted:true,
				strict: true,
				values: values,
				step: 1,
				onSlide: function(v) { $('date_range').innerHTML = dateFor(v) },
				onChange: function(v) { 
					$('status').innerHTML = 'Sending request...';
					refresh();
				}
			}
		);

		function dateFor(v) {
			start_date = dates[v[0]];
			end_date = dates[v[1]];
			return start_date + ' through ' + end_date;
		}
	// ]]>
	</script>

  </body>

</html>
