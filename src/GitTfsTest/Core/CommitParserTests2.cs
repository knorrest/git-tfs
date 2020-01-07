using System.Collections.Generic;
using GitTfs.Core;
using Xunit;

namespace GitTfs.Test.Core
{
    public class CommitParserTests2 : BaseTest
    {
        public static IEnumerable<object[]> Cases
        {
            get
            {
                return new[] {
                    new object[] { "git-tfs-id: foo;C123", true, 123 },
                    new object[] { "git-tfs-id: handle more than Int32;C" + int.MaxValue, true, int.MaxValue },
                    new object[] { "foo-tfs-id: bar;C123", false, 0 },
                    new object[] { "\ngit-tfs-id: foo;C234\n", true, 234 },
                    new object[] { "\r\ngit-tfs-id: foo;C345\r\n", true, 345 },
                    new object[] { "commit message\n4567\ngit-tfs-id: foo;C1234\nee\n4567", true, 1234 },
                    new object[] { "\r\ngit-tfs-id: foo;C888", true, 888 },
                    new object[] { "commit message\r\n4567\r\ngit-tfs-id: foo;C12345\r\nee\r\n4567", true, 12345 },
                    new object[] { "commit message\r\ngit-tfs-id: foo;C1\r\ngit-tfs-id: foo;C2\r\nee\r\n4567", true, 2 }, //if 2 are possible, choose last (but should never happen!)
                    new object[] { "commit message\r\ngit-tfs-id: foo;\r\n foo;C2\r\nee\r\n4567", false, 0 }, //RegEx must not begin on one line and finish on a second one
                };
            }
        }


        [Theory]
        [MemberData(nameof(Cases))]
        public void Run(string message, bool expectParsed, int expectId)
        {
            int id;
            bool parsed = GitRepository.TryParseChangesetId(message, out id);
            Assert.Equal(expectParsed, parsed);
            if (parsed)
            {
                Assert.Equal(id, expectId);
            }
        }

        public void f(string a,string b, string c, string d, string e,string f, string g, string h)
        {
            int a;
            int b;
            int c;
            for (int d=1;d<10;++d)
            {
            if (a)
            {
                if (b)
                    c = 1;
                else if (b)
                {
                    if (c)
                        a = 1;
                    else
                        a = 2;
                }       
            }
            }
        }
        public void g()
        {
            int a;
            int b;
            int c;
            for (int d=1;d<10;++d)
            {
            if (a)
            {
                if (b)
                    c = 1;
                else if (b)
                {
                    if (c)
                        a = 1;
                    else
                        a = 2;
                }       
            }
            }
        }
        public void h()
        {
            int a;
            int b;
            int c;
            for (int d=1;d<10;++d)
            {
            if (a)
            {
                if (b)
                    c = 1;
                else if (b)
                {
                    if (c)
                        a = 1;
                    else
                        a = 2;
                }       
            }
            }
        }
    }
}
