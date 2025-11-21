# Unity Tech Test – Welding & Crafting Prototype

-Watch a short gameplay walkthrough here: https://youtu.be/_mKjFQrhxSw

-Playable build link (click and download source.zip and play .exe in _Build):<br />
https://github.com/JuanMandon/Rysesoft-mandon/releases/tag/Playable

# Overview

This Unity 2022.3.43f1 project demonstrates a welding and crafting system with interactive items, world UI feedback, and inventory management. It is designed to highlight clean, modular code and extensibility.

Completed in under 4 hours, the prototype focuses on core gameplay systems and code speed.

## Core Systems

-Workbench Interaction: Open a crafting interface via the workbench.

-Welding System: Place objects, weld them by holding left mouse, and trigger visual effects (particles, scaling animations, progress feedback). Fully welded objects automatically appear in the inventory.

-World UI: Welding progress updates in real-time with a world-facing UI that always looks at the camera.

## Inventory System (UI):

-Items spawned from welded objects automatically populate the pile.

-Transfer items between pile and player inventory with a single button press.

-Supports multiple item types via prefabs.

-Fully driven by UnityEvents for flexibility and expansion.

# Features

## Interact System:

-Raycast-based interaction with objects (IInteractable) including Workbench and Item Piles.

-UI indicator and interact label update dynamically when looking at an interactable object.

## Welding Mechanics:

-Weldable objects contain multiple WeldPoints that activate when hit.

-Welding progress updates a world-space UI percentage.

-Fully welded objects trigger particle effects, scale animations (using DOTween), and automatically add items to the inventory.

## Inventory & Item Handling:

-Prefabs are instantiated into a UI pile.

-Items can be transferred between pile and player inventory.

-InventoryTransfer singleton handles all inventory logic, allowing prefabs to add items via UnityEvents without manual wiring.

## UI & Camera Integration:

-All world UI elements face the main camera (LookAtCamera).

-Inventory and weld progress UI scales and updates dynamically.

# Implementation Notes

-Singleton pattern used for InventoryTransfer to centralize and simplify inventory management for this prototype.

-Fully welded objects automatically add themselves to the inventory via UnityEvents, removing manual wiring.

-Event-driven architecture: while a singleton was used for speed, in production a full event bus, observer pattern, or dependency injection system would allow completely decoupled communication between systems.

-Focus was on functionality, readability, and rapid implementation, rather than exhaustive polish.

-DOTween sequences used for smooth welding feedback and dynamic world-space UI.

# How to Play

-Look at the Workbench and press E to open the crafting window.

-Place a weldable object with left click and hold left mouse to weld it in the intersection between objects.

-Watch the weld progress update in world UI.

-Fully welded objects automatically appear in the inventory pile.

-Use the transfer button to move items between pile and player inventory.

## Notes

-Focus is on gameplay logic, UI interaction, and readable code, rather than high-fidelity visuals or perfect code.

-Inventory system is fully functional in UI and demonstrates multiple inventories integration via welded objects (transfer from pile to player inventory and viseversa).

-Systems are modular and ready for future expansion.
