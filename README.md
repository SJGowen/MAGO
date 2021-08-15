# MAGO
Airplane Parking Assistant for Manchester Airport

Problem

As an airplane parking assistant, so that I can efficiently manage parking slots, I want to be recommended a parking slot when a new airplane arrives. And to be able to book the plane into that parking slot.

Notes

*	A plane may be parked for a few hours or a few days. (ArrivalDateTime & DepartureDateTime recorded for comparison with the GroundTimeEstimate recorded in Minutes. When Stand is getting full, you can look for Aircraft with short GroudTimeEstimate's and park these Aircraft in a larger Stands. Also recorded AirLine in Airplane as for larger Airports I believe that they park Aircraft from one Airline together.)
* There are 100 slots, but they are not of the same size, (I have used Stand instead of Slot as I think this refers to Aircraft parking space)
  *	25 for Jumbos (A380, B747)
  *	50 for Jets (A330, B777)
  * 25 for Props (E195)
*	Only the plane types listed above will arrive at the airport
*	Smaller planes can park in larger slots, but not the other way around.
*	If no slot is available, an obvious alert should be raised.
*	We have yet to select the device or the data storage mechanism that will be used.
*	Consider how airlines might pre-book slots in a future iteration of this product.
