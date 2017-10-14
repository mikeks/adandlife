<%@ Control Language="C#" %>
<style>
.stage-pic-div {
	width: 1050px;
    background-color: #dcdcdc;
    padding: 10px;
    text-align: center;
    margin: auto;
    margin-bottom: 25px;
	font-size: 19px;
    letter-spacing: 4px;
}
</style>
<script runat="server">

	void Skip(int cnt)
	{
		for (int i = 0; i < cnt; i++)
		{
			Response.Write("<td></td>");
		}
	}

	private string row = "A";

	void NextRow()
	{
		Response.Write("</tr><tr>");
		row = "" + (Char)(Convert.ToUInt16(row[0]) + 1);
		if (row == "I") row = "J";
		Response.Write("<td>" + row + "</td>");
	}

	void Seats(int fr, int to, int step)
	{
		int i = fr;
		do
		{
			Response.Write(string.Format("<td><a data-n=\"{0}{1}\">{1}</a></td>", row, i));
			i += step;
			if (step > 0)
			{
				if (i > to) break;
			}
			else
			{
				if (i < to) break;
			}
		} while (true);

		Response.Write("<td></td>");
	}

	void allSeats()
	{
		Skip(13);
		Seats(125, 101, -2);
		Seats(102, 126, 2);

		for (int i = 0; i < 6; i++)
		{
			NextRow();
			Skip(3);
			Seats(17, 1, -2);
			Seats(125, 101, -2);
			Seats(102, 126, 2);
			Seats(2, 18, 2);
		}

		for (int i = 0; i < 7; i++)
		{
			NextRow();
			Skip(2);
			Seats(19, 1, -2);
			Seats(125, 101, -2);
			Seats(102, 126, 2);
			Seats(2, 20, 2);
		}

		for (int i = 0; i < 7; i++)
		{
			NextRow();
			Skip(1);
			Seats(21, 1, -2);
			Seats(125, 101, -2);
			Seats(102, 126, 2);
			Seats(2, 22, 2);
		}

		for (int i = 0; i < 2; i++)
		{
			NextRow();
			Seats(23, 1, -2);
			Seats(125, 101, -2);
			Seats(102, 126, 2);
			Seats(2, 24, 2);
		}

	}

</script>

<div class="hall-map-cont">

	<table class="hall-map">
		<tr>
			<td colspan="57">
				<div class="stage-pic-div">
					СЦЕНА
				</div> 
			</td>
		</tr>
		<tr>
			<td>A</td>
			<% 
				allSeats();
			%>
		</tr>
	</table>

</div>
