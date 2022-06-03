package models;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;


public class MemberData {

	

		
		final String JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";  // jdbc 드라이버 주소
		final String DB_URL = "jdbc:mysql://localhost:3306/jojunhee?useSSL=false"; // DB 접속 주소
		//localhost는 접속하려는 데이터베이스 주소를 입력하시면 됩니다. localhost를 사용하면 됩니다.
		//3306은 데이터베이스에 접속할때 사용하는 포터번호입니다. 설치할때 설정한 포트번호를 사용합니다.
		//databasename에는 접속하려는 database의 name을 입력해줍니다.
		final String USERNAME = "root"; // DB ID
		final String PASSWORD = "00000000"; // DB Password

		
	

	public void aad() {
		
		// MySql에 사용하는여러 객체를 만들어줍니다.
		Connection conn = null;
		Statement stmt = null;
		ResultSet rs = null;
		
		System.out.print("User Table 접속 : ");
		try {
			Class.forName(JDBC_DRIVER); //Class 클래스의 forName()함수를 이용해서 해당 클래스를 메모리로 로드 하는 것입니다.
			//URL, ID, password를 입력하여 데이터베이스에 접속합니다.
			conn = DriverManager.getConnection(DB_URL,USERNAME,PASSWORD); 
			
			// 접속결과를 출력합니다.
			if (conn != null){System.out.println("성공");}
			else{System.out.println("실패");}
				
		} catch (ClassNotFoundException e) {
			System.out.println("Class Not Found Exection");
			e.printStackTrace();
		} catch (SQLException e) {
			System.out.println("SQL Exception : " + e.getMessage());
			e.printStackTrace();
		}	

	}
	
}
