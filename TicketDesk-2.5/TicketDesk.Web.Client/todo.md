﻿- Setup demo mode
  - Reset function should: re-seeds the database, rebuilds search indexes, clears file storage
  - Run reset on startup, or manually from admin

- Refactor ticketstatus filtering to use the enum
> consider if we need to add any and open to the enum, or how best to handle that case

- Refactor ticketcenter filter dropdowns to use selectlist extensions

- Consider hiding disabled filters in ticket center lists to conserve screen space

- See about squeezing or re-designing the ticketcenter grid to fit phone screen sizes better

- Tweak formatting for filterbar when collapsed

- Get a logo that isn't too wide to fit down to bootstrap size sm, then switch to mobile logo
> get a designer, or someone better than I am at images to design it

- Fix about menu item to render text when nav menu collapsed 

- Redesign applicaiton settings to for json
 - Related Settings go in Group at the table row
 - individual keys/values as json value column
 - strongly typed EF model (similar to user settings)  

- Search decide if/how to automate full-index rebuilds (on startup, after elapsed time, whatever). 

- Settings:
  - account for search settings
   - index boost-factors
   - which provier to use (or auto-detect like it does now)
   - index location (lucence only, fixed path or special "datadirectory" value)
  - re-iplement all ticket center and editor settings

- Remove all mvc areas
  - fix all action and url links to remove the viewdata for areas