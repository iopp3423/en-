package use;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;


public class Database {
	
	Connection conn = null; //DB 커넥션 연결 객체

    
    public void db()
    {
    	
    	String USERNAME = "root";//DBMS접속 시 아이디
    	String PASSWORD = "00000000";//DBMS접속 시 비밀번호
    	String URL = "jdbc:mysql//localhost:3306/boarddb";//DBMS접속할 db명
    	
    	try {
            System.out.println("생성자");
            Class.forName("c.mysql.cj.jdbc.Driver");
            conn = DriverManager.getConnection(URL, USERNAME, PASSWORD);
            System.out.println("드라이버 로딩 성공");
        } catch (Exception e) {
            System.out.println("드라이버 로딩 실패 ");
            try {
                conn.close();
            } catch (SQLException e1) {    }
        }
    }
}
