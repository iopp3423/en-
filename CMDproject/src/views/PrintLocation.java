package views;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;

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
	
	public void printDir(SimpleDateFormat date, String attribute, String size, File dirList) {
		
		System.out.printf("%s %3s %6s %s \n",date.format(new Date(dirList.lastModified())), attribute,size,dirList.getName());
	}
}