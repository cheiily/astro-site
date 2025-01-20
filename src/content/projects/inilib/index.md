---
title: 'inilib'
description: "c++ .ini parser"
toc: true
status: "Closed"
entry_type: "project"
order: 5
urls:
    - https://github.com/cheiily/IniLib
url_names:
    - repo
---

## /links

- https://github.com/cheiily/IniLib

## /motivation

First real jab at a 'personal project', inspired by a uni task requiring us to parse data from a chosen text format.
Also first time using a testing framework.

## /technologies

- C++17
- Boost
- Cmake

## /implementation

The project uses an organized sample-based testing layout. The output structure is organized into a map-based section tree with string entries.
Smart pointers are used to manage the memory and lifetimes of each tree node.

## /conclusions

The core feature of the tool was realized and is fully functional - the tool correctly parses the base ini format and turns it into a functional, traversable tree.
Unfortunately distracted by the increasingly busy semester plan as well as the release of Elden Ring :), the other planned features were left unimplemented.
