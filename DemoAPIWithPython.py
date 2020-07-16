#!/cygdrive/d/python2718/python

#
# Demo of wellrested usage for RESTA API Testing
# ./DemoAPIWithPython.py -v
#

import json
import httplib
import unittest
import wellrested

class DemoAPIWithPython(unittest.TestCase):
    URL = 'https://jsonplaceholder.typicode.com'
    USER = 'peter.zhang'
    CAREER = 'automationTester'

    def test_post(self):
        rest_client=wellrested.JsonRestClient(DemoAPIWithPython.URL)
        enqueue_data = {
                'name': DemoAPIWithPython.USER,
                'career': DemoAPIWithPython.CAREER
        }
        response = rest_client.post('/posts', enqueue_data)
        self.assertEqual(response.status_code, httplib.CREATED)
        json_content = json.loads(response.content)
        self.assertEqual(json_content['name'], DemoAPIWithPython.USER)
        self.assertEqual(json_content['career'], DemoAPIWithPython.CAREER)
      
if __name__ == '__main__':
    unittest.main()
