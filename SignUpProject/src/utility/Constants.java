package utility;

public class Constants {

	public static final int SCREEN_SIZE_WIDTH = 1280;
	public static final int SCREEN_SIZE_HEIGHT = 720;
	
	public static final String JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";  // jdbc 드라이버 주소
	public static final String DB_URL = "jdbc:mysql://localhost:3306/jojunhee?useSSL=false"; // DB 접속 주소
	public static final String USERNAME = "root"; // DB ID
	public static final String PASSWORD = "00000000"; // DB Password
	
	
	public static final String PWCHECK = "^[0-9a-z]{7,14}+$";
	public static final String BIRTH = "^(?:[0-9]{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[1,2][0-9]|3[0,1]))$";
	public static final String EMAIL = "^[0-9a-zA-Z]{4,14}+$";
	public static final String CALLNUMBER = "^[0-9]{8}+$";
	public static final String NAMEKOREAN = "^[가-힣]{2,4}+$";
	public static final String NAMEENGLSIGH = "^[a-zA-Z]{2,10}+$";
	
}
