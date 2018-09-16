<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rss.aspx.cs" Inherits="AdAndLifeWebsite.rss" %><?xml version="1.0" encoding="utf-8"?>
<?xml-stylesheet type="text/xsl" href="viewrss.xsl"?>
<rss version="2.0" xmlns:atom="http://www.w3.org/2005/Atom">
	<channel>
		<title>Реклама и Жизнь, Филадельфия</title>
		<description>Бесплатный сервис объявлений газеты Реклама и Жизнь, Филадельфия</description>
		<link>http://adandlife.com</link>
		<language>ru</language>
		<copyright>Vital Connections LLC &amp; Keskinov LLC</copyright>
		<item>
			<link>http://adandlife.com/classified.aspx?ad=<%= AdId %></link>
			<guid><%= AdId %></guid>
			<description><![CDATA[<%= AdText %>]]></description>
		</item>
	</channel>
</rss>
