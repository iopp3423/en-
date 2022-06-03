package models;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import utility.Constants;


public class MemberData {


	
	public List<MemberDto> returnMember() { //데베 회원리스트 저장 후 반
		List<MemberDto> member = new ArrayList<MemberDto>();
		
		// MySql에 사용하는 객체 생
				Connection conn = null;
				Statement statement = null;
				ResultSet Contents = null;
					
				try {
		            // JDBC 드라이버 로딩
		            Class.forName(Constants.JDBC_DRIVER);

		            // Connection 객체 생성
		            conn = DriverManager.getConnection(Constants.DB_URL, Constants.USERNAME, Constants.PASSWORD); // DB 연결

		            // Statement 객체 생성
		            statement = conn.createStatement();

		            // SQL 문장을 실행하고 결과를 리턴
		            // statement.excuteQuery(SQL) : select
		            // statement.excuteUpdate(SQL) : insert, update, delete ..
		            Contents = statement.executeQuery("SELECT * FROM member");

		            // ResultSet에 저장된 데이터 얻기 - 결과가 2개 이상    
	                while (Contents.next())
	                {     
	                    member.add(new MemberDto(Contents.getString("name"), Contents.getString("id"), Contents.getString("pw"), Contents.getString("birth"), Contents.getString("email"),
	                    						Contents.getString("callnumber"),Contents.getString("address"),Contents.getString("zipcode")));             
	                }
		            
		        } catch (SQLException e) {

		            System.out.println("SQL Error : " + e.getMessage());

		        } catch (ClassNotFoundException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}finally {
		        	closeConn(conn, statement, Contents);
		        }
		
		return member;
	}
	
	public void addMember(String name, String id, String password, String passwordCheck, String birth, String email, String callNumber, String address, String zipCode) {
		Connection conn = null;
		Statement statement = null;
		ResultSet Contents = null;
			
		try {
            // JDBC 드라이버 로딩
            Class.forName(Constants.JDBC_DRIVER);

            // Connection 객체 생성
            conn = DriverManager.getConnection(Constants.DB_URL, Constants.USERNAME, Constants.PASSWORD); // DB 연결

            // Statement 객체 생성
            //statement = conn.createStatement();

            // SQL 문장을 실행하고 결과를 리턴
            // statement.excuteQuery(SQL) : select
            // statement.excuteUpdate(SQL) : insert, update, delete ..
            String query = "INSERT INTO member(name,id, pw, birth, email, callnumber, address, zipcode)" + "VALUES(?, ?, ?, ?, ?, ?, ?, ?)";
            //statement.executeUpdate("INSERT INTO member(name,id, pw, birth, email, callnumber, address, zipcode)" + "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)");
            
            PreparedStatement preparedStmt = conn.prepareStatement(query);
            preparedStmt.setString (1, name);
            preparedStmt.setString (2, id);
            preparedStmt.setString (3, password);
            preparedStmt.setString (4, birth);
            preparedStmt.setString (5, email);
            preparedStmt.setString (6, callNumber);
            preparedStmt.setString (7, address);
            preparedStmt.setString (8, zipCode);
            preparedStmt.execute();
      
        } catch (SQLException e) {

            System.out.println("SQL Error : " + e.getMessage());

        } catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}finally {
        	closeConn(conn, statement, Contents);
        }
	}
	
	
	public void aad() {
		
		// MySql에 사용하는 객체 생
		Connection conn = null;
		Statement statement = null;
		ResultSet Contents = null;
			
		try {
            // JDBC 드라이버 로딩
            Class.forName(Constants.JDBC_DRIVER);

            // Connection 객체 생성
            conn = DriverManager.getConnection(Constants.DB_URL, Constants.USERNAME, Constants.PASSWORD); // DB 연결

            // Statement 객체 생성
            statement = conn.createStatement();

            // SQL 문장을 실행하고 결과를 리턴
            // statement.excuteQuery(SQL) : select
            // statement.excuteUpdate(SQL) : insert, update, delete ..
            Contents = statement.executeQuery("SELECT * FROM member");

            // ResultSet에 저장된 데이터 얻기 - 결과가 2개 이상
            while (Contents.next()) {

                String id = Contents.getString("id");
                String pass = Contents.getString("name");
                String name = Contents.getString("pw");
                String phone = Contents.getString("callnumber");
                System.out.println(id + " " + pass + " " + name + " " + phone);
            }

            // ResultSet에 저장된 데이터 얻기 - 결과가 1개
            // if(Contents.next()) {
            //
            // }
            // else {
            //
            // }
        } catch (SQLException e) {

            System.out.println("SQL Error : " + e.getMessage());

        } catch (ClassNotFoundException e1) {

            System.out.println("[JDBC Connector Driver 오류 : " + e1.getMessage() + "]");

        } finally {
        	closeConn(conn, statement, Contents);
        }

	}
		
	private void closeConn(Connection conn, Statement statement, ResultSet Contents) {
		//사용순서와 반대로 close 함
        if (Contents != null) {
            try {
                Contents.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
        if (statement != null) {
            try {
                statement.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }

        if (conn != null) {
            try {
            	conn.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
	}
	
	
		
	
}

