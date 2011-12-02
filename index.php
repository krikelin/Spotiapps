<?php
include("top.php");
$title="Home";
?>
<table>
	<tr>

		<td>
<H3 style="color: #550055">News</H3>
			<?php
		
	$af = mysql_connect("localhost","krakelin_wrdp1","R{8cUok7Ti7C");
mysql_select_db("krakelin_wrdp1"); 
$SQL="SELECT * FROM wp_posts WHERE post_status='publish' AND post_author=4 ORDER BY post_date DESC LIMIT 3";
$result=mysql_query($SQL);
while($posts = mysql_fetch_array($result)){?>
		<H3><?php echo $posts["post_title"]?><br/>
		<div class="date"><?php echo $posts["post_date"]?></div>
		</H3>
		<p>
	
		<?php echo $posts["post_content"]?>
		</p>
		<hr/>
		<?php
			
		}

		?>
		</td>
		
	</tr>
	
</table>