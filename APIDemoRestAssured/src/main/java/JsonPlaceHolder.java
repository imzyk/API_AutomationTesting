import org.json.simple.JSONObject;
import org.junit.Assert;

import org.springframework.http.HttpStatus;
import static io.restassured.RestAssured.*;

public class JsonPlaceHolder {
    final static String url = "https://jsonplaceholder.typicode.com";
    final static String name = "peter.zhang";
    final static String career = "automationTester";

    public static void main(String args[]) {

        JSONObject requestParams = new JSONObject();
        requestParams.put("name", name);
        requestParams.put("career", career);
        String response = given().contentType("application/json").body(requestParams.toJSONString()).
                when().post(url + "/posts").
                then().assertThat().statusCode(HttpStatus.CREATED.value()).
                extract().asString();

        Assert.assertTrue(response.contains(name));
        Assert.assertTrue(response.contains(career));
    }
}
