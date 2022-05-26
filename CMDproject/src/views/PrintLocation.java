package views;

public class PrintLocation {

	
	public void printNotice() {
		System.out.println("Microsoft Windows [Version 10.0.19043.1706]");
		System.out.println("(c) Microsoft Corporation. All rights reserved.");
		System.out.println();
	}
	public void printCurrentLocation(String location, String errorMessage, boolean is_Not_Error)
	{
		if(is_Not_Error) {
			System.out.printf(location);
		}
		else if(!is_Not_Error) {
			System.out.println(errorMessage);
			System.out.printf(location);
		}
	}
}