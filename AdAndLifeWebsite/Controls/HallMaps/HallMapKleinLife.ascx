<%@ Control Language="C#" %>
<style>
.stage-pic-div {
	width: 900px;
    background-color: #dcdcdc;
    padding: 10px;
    text-align: center;
    margin: auto;
    margin-bottom: 25px;
	font-size: 19px;
    letter-spacing: 4px;
}
</style>
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
			<td></td>
			<td></td>
			<td></td>
			<td></td>
			<% for (int i = 7; i >= 1; i -= 2)
				{ %>
			<td><a data-n="A<%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 115; i > 100; i--)
				{ %>
			<td><a data-n="A<%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 2; i <= 8; i += 2)
				{ %>
			<td><a data-n="A<%=i %>"><%=i %></a></td>
			<% } %>
		</tr>

		<tr>
			<td>B</td>
			<td></td>
			<td></td>
			<td></td>
			<% for (int i = 9; i >= 1; i -= 2)
				{ %>
			<td><a data-n="B<%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<td></td>
			<% for (int i = 114; i > 100; i--)
				{ %>
			<td><a data-n="B<%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 2; i <= 10; i += 2)
				{ %>
			<td><a data-n="B<%=i %>"><%=i %></a></td>
			<% } %>
		</tr>


		<tr>
			<td>C</td>
			<td></td>
			<td></td>
			<% for (int i = 11; i >= 1; i -= 2)
				{ %>
			<td><a data-n="C<%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 115; i > 100; i--)
				{ %>
			<td><a data-n="C<%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 2; i <= 12; i += 2)
				{ %>
			<td><a data-n="C<%=i %>"><%=i %></a></td>
			<% } %>
		</tr>

		<tr>
			<td>D</td>
			<td></td>
			<% for (int i = 13; i >= 1; i -= 2)
				{ %>
			<td><a data-n="D<%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<td></td>
			<% for (int i = 114; i > 100; i--)
				{ %>
			<td><a data-n="D<%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 2; i <= 14; i += 2)
				{ %>
			<td><a data-n="D<%=i %>"><%=i %></a></td>
			<% } %>
		</tr>

		<% var lt = "E"; %>
		<tr>
			<td><%= lt %></td>
			<% for (int i = 15; i >= 1; i -= 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 115; i > 100; i--)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 2; i <= 16; i += 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>
		</tr>

		<% lt = "F"; %>
		<tr>
			<td><%= lt %></td>
			<% for (int i = 15; i >= 1; i -= 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<td></td>
			<% for (int i = 114; i > 100; i--)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 2; i <= 16; i += 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>
		</tr>

		<% lt = "G"; %>
		<tr>
			<td><%= lt %></td>
			<% for (int i = 15; i >= 1; i -= 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 115; i > 100; i--)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 2; i <= 16; i += 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>
		</tr>

		<% lt = "H"; %>
		<tr>
			<td><%= lt %></td>
			<% for (int i = 15; i >= 1; i -= 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<td></td>
			<% for (int i = 114; i > 100; i--)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 2; i <= 16; i += 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>
		</tr>

		<% lt = "J"; %>
		<tr>
			<td><%= lt %></td>
			<% for (int i = 15; i >= 1; i -= 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 115; i > 100; i--)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 2; i <= 16; i += 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>
		</tr>

		<% lt = "K"; %>
		<tr>
			<td><%= lt %></td>
			<% for (int i = 15; i >= 1; i -= 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 115; i > 100; i--)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 2; i <= 16; i += 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>
		</tr>

		<% lt = "L"; %>
		<tr>
			<td><%= lt %></td>
			<% for (int i = 15; i >= 1; i -= 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<td></td>
			<% for (int i = 114; i > 100; i--)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 2; i <= 16; i += 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>
		</tr>

		<% lt = "M"; %>
		<tr>
			<td><%= lt %></td>
			<% for (int i = 15; i >= 1; i -= 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<td></td>
			<td></td>
			<% for (int i = 113; i > 100; i--)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<% for (int i = 2; i <= 16; i += 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>
		</tr>

		<% lt = "N"; %>
		<tr>
			<td><%= lt %></td>
			<% for (int i = 15; i >= 1; i -= 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<td></td>
			<td></td>
			<% for (int i = 112; i > 100; i--)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>
			<td></td>

			<td></td>

			<% for (int i = 2; i <= 16; i += 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>
		</tr>


		<% lt = "O"; %>
		<tr>
			<td><%= lt %></td>
			<% for (int i = 15; i >= 1; i -= 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>

			<td></td>

			<td></td>
			<td></td>
			<td></td>
			<td></td>
			<% for (int i = 110; i > 100; i--)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>
			<td></td>

			<td></td>

			<% for (int i = 2; i <= 16; i += 2)
				{ %>
			<td><a data-n="<%= lt %><%=i %>"><%=i %></a></td>
			<% } %>
		</tr>


	</table>

</div>
