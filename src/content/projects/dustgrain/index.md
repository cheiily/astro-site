---
title: 'dustgrain'
description: "Dustloop scraper util with CLI interface"
toc: true
order: 2
status: "v2.0.3"
entry_type: "project"
urls:
    - https://github.com/cheiily/DustGrain
url_names:
    - repo
---

## /motivation

While hanging around the FGC and then developing [HeartBlazer](/projects/heartblazer), I've always been thinking how cool it would be to have a quick reference lookup whenever I wanted to check some frame data or the like. The caveat was that there was no decent tool available out there. I've also been looking at writing some basic project to kickstart the kotlin learning.\
So I took the opportunity that Java interoperates with Kotlin, and decided to make one myself.

## /technologies

- Kotlin
	- Clikt
	- Jsoup

## /implementation

I started with the idea that it was going to be just a submodule for the bot but while developing I diverged to also make it a CLI tool, just because I'd been really wanting to do put that into any project for a while, but none were quite fitting before this. 

The tool's core utilizes Java-interop to interact with Jsoup, the library of choice for HTML parsing.
As it is a scraper, it is obviously dependent on Dustloop's element layout but considering its consistency across numerous sub-wikis, I believe it should not be a concern in the nearest future.
The tool, however, is suited to pull data from multiple wikis as it navigates the structure via selectors and accesses a parsed URL based on user input, rather than having hardcoded values. As there is no facilitation for matching inexact user input to the obtained values, the input criteria is very strict.

For the CLI interface, I decided to use Clikt as it was the most popular actively-maintained argument parser available. Its structure proved rather surprising to me, as it was more of a full CLI-tool framework than just simple parser, but nevertheless I grew to like it.

## /conclusions

This project while very simple in essence allowed me to get a basic grasp on Kotlin's semantics and workings, as well as the JVM interoperability. I've also learnt about the structure of a CLI tool, which was pretty satisfying.

All of the basic funtionality I've inteded for it has been implemented so the project can be marked closed and finished.
Optionally, if I ever feel like coming back to this, I may add some regex-based input-to-move matching or a list-wiki and list-characters command. Possibly while working this into HeartBlazer. Who knows.