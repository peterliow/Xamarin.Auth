//
//  Copyright 2012-2013, Xamarin Inc.
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
using System;
using NUnit.Framework;
using System.Linq;

namespace Xamarin.Auth.Test
{
	[TestFixture]
	public class AccountTest
	{
		[Test]
		public void Delete ()
		{
			var store = AccountStore.Create ();
			
			// Store a test account
			var account = new Account ("xamarin_delete");
			store.Save (account, "test");
			
			// Make sure it was stored
			var saccount = store.FindAccountsForService ("test").FirstOrDefault (a => a.Username == "xamarin_delete");
			Assert.That (saccount, Is.Not.Null);
			
			// Delete it
			store.Delete (saccount, "test");
			
			// Make sure it was deleted
			var daccount = store.FindAccountsForService ("test").FirstOrDefault (a => a.Username == "xamarin_delete");
			Assert.That (daccount, Is.Null);
		}
	}
}

