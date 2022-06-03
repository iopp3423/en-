package start;

import java.io.File;
import java.net.PasswordAuthentication;
import java.util.Properties;
import java.util.Scanner;
import java.util.regex.Pattern;

import controls.SignUpController;
import controls.test;

import com.mysql.cj.Session;


public class Start {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		//SignUpController controller = new SignUpController();
		
		test ts = new test();
		ts.naverMailSend();
	}

}
