package use;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;


public class Database {
	
	Connection conn = null; //DB 커넥션 연결 객체

    
    public void db()
    {
    	
    	String USERNAME = "root";//DBMS접속 시 아이디 
    	String PASSWORD = "00000000";//DBMS접속 시 비밀번호
    	String URL = "jdbc:mysql//localhost:3306/boarddb";//DBMS접속할 db명
    	Connection conn = null;
        Statement stmt = null;
        ResultSet rs = null;
    	
    	try {
            System.out.println("생성자");
            Class.forName("com.mysql.jdbc.Driver");
            String url = "jdbc:mysql://localhost/jojunhee";

            conn = DriverManager.getConnection(url, "root", "00000000");
            System.out.println("연결 성공");
            
            String sql = "SELECT * FROM LOG";
            
            rs = stmt.executeQuery(sql);
            
            //String name = rs.getString(number);
            while(rs.next()){
                // 레코드의 칼럼은 배열과 달리 0부터 시작하지 않고 1부터 시작한다.
                // 데이터베이스에서 가져오는 데이터의 타입에 맞게 getString 또는 getInt 등을 호출한다.

                //System.out.println(name);
            }
        
            
        } 
    	catch (Exception e) {
            System.out.println("드라이버 로딩 실패 ");
            try {
                conn.close();
            } catch (SQLException e1) {    }
        }
    }
   
    
    
    public void data()
    {
    	Connection conn;
    	Statement stmt;
    	String url = "jdbc:mysql://localhost/jojunhee";
    	 
    	try {
    		ResultSet rs = null;
    		
			conn = DriverManager.getConnection(url, "root", "00000000");
			stmt = conn.createStatement();
			System.out.println("Statement객체 생성 성공");
			
			stmt.executeQuery("select * from LOG");
			
			System.out.println("연결성공");
			stmt.close();
			conn.close();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
    	
    	
    }
    
    
    
}
