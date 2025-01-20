---
title: 'steamlog'
description: "CLI background app creating steam play history"
toc: true
status: "Closed"
entry_type: "project"
order: 9
urls:
    - https://github.com/cheiily/SteamLog_Puller
url_names:
    - repo
---

Background CLI application frequently polling the Steam API to create a local play history for further analysis.
Built in Java.

## /links

- https://github.com/cheiily/SteamLog_Puller

## /motivation

Frustrated by the lack of any extensive history analysis tool for steam history, as steam only offers playtime and a monthly breakdown with the yearly summary, I decided to write a tool that could gather such info for myself.

## /technologies

- Java 17
- logback

## /implementation

The project contains a couple of structures to represent the steam API response value and a connection(request) builder being ran in a looping thread. The tracked profiles can be configured via UID or Vanity ID through config.ini, which also handles the api key as well as refresh behavior configuration - the delay of subsequent requests as well as failed request amount thresholds that controll when to go to the next level of delay, in order to save api calls as Valve puts a daily limit on that.
Each request is analyzed and if it is different from the last recorded status - it is serialized and saved to file via a customized logback setup. From there it can be analyzed further for a visual representation of the recorded history.

## /conclusions

This project was my first real look into using a real logging framework and customizing one to my needs, and in that I can declare it successful. Sadly, I have not put this to as much use as I would've liked to, including not having made the visual analyzer. It's not completely off my radar, there are just higher priorities currently.

